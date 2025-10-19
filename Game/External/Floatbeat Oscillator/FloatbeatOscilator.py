import numpy as np
from scipy.io import wavfile
import os

class FloatBeatOscillator:
    def __init__(self, sample_rate=45172):
        self.sr = sample_rate
        self.t = 0
        self.a = 0.0
        self.b = 0.0
        self.PI = np.pi
        
    def f(self, c, d):
        """Helper function from original formula"""
        return (np.sin(c / 256 * self.PI) ** d / 2 * 
                ((-int(c) >> 8) & 1) * ((-int(c) >> 9) & 1))
    
    def generate_sample(self):
        """Generate single sample"""
        t = self.t
        
        # Update a and b (random logic)
        if t > 0:
            rand_val = np.random.random() - 0.5
            self.a += rand_val
            self.a /= 2
            self.b += self.a / 3 - self.b / 3
        else:
            self.a = 0.0
            self.b = 0.0
        
        a = self.a
        b = self.b
        
        # HARDCODED FORMULA (fast version)
        # Part 1
        c_val = 2 * t * (2 + ((t >> 13) & 1)) * 2 ** ([0, -5, -3, -7][t >> 16 & 3] / 12)
        d_val = int(0.75 * int(1.3 + int([t >> 10, -t >> 10][t >> 15 & 1] & 31)))
        part1 = (self.f(c_val, d_val) * ((-t >> 8) & 31) / 32 - 0.1) * min(t >> 11, 256) / 140
        
        # Part 2
        pitched_val = t * 2 ** ([0, -5, -7, -8][t >> 16 & 3] / 12) / 64
        part2 = ((int(pitched_val) & 3) / 13) * (t > 262144)
        
        # Part 3
        f_val = t * 1.5 * self.PI / 64 * 2 ** ([[-8, -12, -15, [-19, -10][t >> 18 & 1]][t >> 16 & 3]][0] / 12)
        part3 = (np.sin(np.sin(np.sin(f_val) + f_val + np.sin(f_val * 2)) + f_val) / 6 * 
                min(t >> 9, 256) / 270)
        
        # Part 4
        part4 = (np.sin(int(t / 6) | int(t / 2.1) ^ int(t / 1.4) >> 1) * 
                ((-t >> 11) & 31) / 64 * (t < 65536) / 8)
        
        # Part 5
        pitched_val2 = t * 2 ** ([0, 2, 4, -3, -5, -8, -7, -5][t >> 16 & 7] / 12)
        part5 = ((int(pitched_val2) % 128) / 400) * (t > 524288)
        
        # Part 6
        g = t % 16384
        part6 = 0.0
        if 0 <= g < 4096:
            part6 = np.sin(np.sqrt(g) * 1.5) / 1.8 * (t > 786432)
        
        # Part 7
        part7 = ((b * ((-t >> 9) & 31) / 13 * ((t >> 14) & 1) + 
                 a * ((-t >> 7) & 31) * ((-t >> 12) & 1) / 32) / 1.3 * 
                (t > 1048576))
        
        result = (part1 + part2 + part3 + part4 + part5 + (part6 + part7) / 1.1)
        
        # Increment time
        self.t += 1
        
        return np.clip(result, -1.0, 1.0)
    
    def set_time(self, t):
        """Set current time position"""
        self.t = t
        # Reset random state
        self.a = 0.0
        self.b = 0.0
    
    def generate_buffer(self, num_samples, start_time=0):
        """Generate buffer of samples (optimized with progress)"""
        # Set starting position
        self.set_time(start_time)
        
        print(f"Generating {num_samples} samples ({num_samples/self.sr:.1f}s) starting from t={start_time} ({start_time/self.sr:.1f}s)...")
        samples = []
        
        # Progress bar
        chunk_size = self.sr  # 1 second chunks
        last_progress = -1
        
        for chunk_start in range(0, num_samples, chunk_size):
            chunk_end = min(chunk_start + chunk_size, num_samples)
            for _ in range(chunk_end - chunk_start):
                samples.append(self.generate_sample())
            
            # Progress (update only when changes)
            progress = int((chunk_end / num_samples) * 100)
            if progress != last_progress:
                print(f"\rProgress: {progress}%", end='', flush=True)
                last_progress = progress
        
        print()  # New line after progress
        return np.array(samples, dtype=np.float32)


def load_formula_from_file(filename):
    """Load FloatBeat formula from .fbm file"""
    if not os.path.exists(filename):
        print(f"Error: File '{filename}' not found!")
        return None
    
    with open(filename, 'r', encoding='utf-8') as f:
        content = f.read().strip()
    
    print(f"Loaded formula from '{filename}'")
    return content


def convert_to_ogg(wav_file, ogg_file):
    """Convert WAV to OGG using ffmpeg"""
    try:
        import subprocess
        print(f"Converting {wav_file} to OGG...", end='', flush=True)
        result = subprocess.run([
            'ffmpeg', '-i', wav_file, 
            '-c:a', 'libvorbis', '-q:a', '6',
            ogg_file, '-y'
        ], check=True, capture_output=True, text=True)
        print(" Done!")
        return True
    except subprocess.CalledProcessError as e:
        print(f" Failed!")
        print(f"Error: {e.stderr}")
        return False
    except FileNotFoundError:
        print(" FFmpeg not found, skipping OGG conversion")
        return False


if __name__ == "__main__":
    print("=" * 60)
    print("FloatBeat Generator")
    print("=" * 60)
    
    # Параметры генерации
    print("\n[Generation Settings]")
    
    # Загрузка формулы (опционально)
    fbm_file = input("Enter .fbm file path (or press Enter to use default): ").strip()
    if fbm_file and fbm_file.endswith('.fbm'):
        formula = load_formula_from_file(fbm_file)
        if not formula:
            print("Using default formula instead.")
    
    # Sample rate
    sample_rate_input = input("Sample rate (default: 45172): ").strip()
    sample_rate = int(sample_rate_input) if sample_rate_input else 45172
    
    # Start time
    start_time_input = input("Start time in seconds (default: 0): ").strip()
    start_time_sec = float(start_time_input) if start_time_input else 0.0
    start_time = int(start_time_sec * sample_rate)
    
    # Duration
    duration_input = input("Duration in seconds (default: 30): ").strip()
    duration = float(duration_input) if duration_input else 30.0
    
    # Output filename
    output_name = input("Output filename (without extension, default: music): ").strip()
    if not output_name:
        output_name = "music"
    
    # Format
    print("\nOutput format:")
    print("  1) WAV only")
    print("  2) OGG only")
    print("  3) Both WAV and OGG")
    format_choice = input("Choose (default: 3): ").strip()
    if not format_choice:
        format_choice = "3"
    
    print("\n" + "=" * 60)
    
    # Генерация
    osc = FloatBeatOscillator(sample_rate=sample_rate)
    num_samples = int(sample_rate * duration)
    
    samples = osc.generate_buffer(num_samples, start_time=start_time)
    
    print(f"Generated {duration}s of audio (t={start_time} to t={start_time + num_samples})")
    
    # Сохранение
    wav_file = f"{output_name}.wav"
    ogg_file = f"{output_name}.ogg"
    
    if format_choice in ["1", "3"]:
        print(f"Saving WAV to '{wav_file}'...", end='', flush=True)
        wavfile.write(wav_file, sample_rate, samples)
        print(" Done!")
    
    if format_choice in ["2", "3"]:
        # Если нужен только OGG, всё равно создаём временный WAV
        if format_choice == "2":
            temp_wav = "_temp.wav"
            wavfile.write(temp_wav, sample_rate, samples)
            convert_to_ogg(temp_wav, ogg_file)
            os.remove(temp_wav)
        else:
            convert_to_ogg(wav_file, ogg_file)
    
    print("\n" + "=" * 60)
    print("Done! Files created:")
    if format_choice in ["1", "3"]:
        file_size_mb = os.path.getsize(wav_file) / (1024 * 1024)
        print(f"  - {wav_file} ({file_size_mb:.2f} MB)")
    if format_choice in ["2", "3"] and os.path.exists(ogg_file):
        file_size_mb = os.path.getsize(ogg_file) / (1024 * 1024)
        print(f"  - {ogg_file} ({file_size_mb:.2f} MB)")
    print("=" * 60)
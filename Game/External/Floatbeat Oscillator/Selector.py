import os
from os import system as g

def initialize_venv():
    g("python -m venv .venv")
    if os.name == 'nt':
    	g(".venv\\Scripts\\pip.exe install numpy scipy")
    else:
        g(".venv/bin/pip install numpy scipy")

ch = input("(1) - Floatbeat to Audio\n >>> ")
if ch == "1":
    initialize_venv()
    if os.name == 'nt':
        g(".venv\\Scripts\\python.exe ./FloatbeatOscilator.py")
    else:
        g(".venv/bin/python ./floatbeat_to_audio.py")
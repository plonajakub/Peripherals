import RPi.GPIO as gpio
from Bluetin_Echo import Echo
from time import *

def led_config(on, off):
    for lon in on:
        gpio.output(lon, gpio.HIGH)
    for lof in off:
        gpio.output(lof, gpio.LOW)

trig = 18
echo = 4
r1 = 12
r2 = 16
y1 = 20
y2 = 21
g1 = 25
g2 = 24

gpio.setmode(gpio.BCM)
gpio.setwarnings(False)


gpio.setup(r1, gpio.OUT)
gpio.setup(r2, gpio.OUT)
gpio.setup(y1, gpio.OUT)
gpio.setup(y2, gpio.OUT)
gpio.setup(g1, gpio.OUT)
gpio.setup(g2, gpio.OUT)

echo = Echo(trig, echo, 340)
dist = None
d_max = 15
d_step = d_max / 6
while True:
    dist = echo.read('cm', 5)
    if dist >= 6*d_step:
        led_config([r1, r2, y1, y2, g1, g2], [])
    elif dist >= 5*d_step:
        led_config([r1, r2, y1, y2, g1], [g2])
    elif dist >= 4*d_step:
        led_config([r1, r2, y1, y2], [g1, g2])
    elif dist >= 3*d_step:
        led_config([r1, r2, y1], [y2, g1, g2])
    elif dist >= 2*d_step:
        led_config([r1, r2], [y1, y2, g1, g2])
    elif dist >= 1*d_step:
        led_config([r1], [r2, y1, y2, g1, g2])
    else:
        led_config([], [r1, r2, y1, y2, g1, g2])

    sleep(0.1)

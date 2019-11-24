import RPi.GPIO as gpio
from w1thermsensor import W1ThermSensor
from time import *

def led_config(on, off):
    for lon in on:
        gpio.output(lon, gpio.HIGH)
    for lof in off:
        gpio.output(lof, gpio.LOW)

data = 18
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

sensor = W1ThermSensor()
temp = None
while True:
    temp = sensor.get_temperature()
    bin_temp_str = str(bin(int(temp)))
    print(bin_temp_str)
    sleep(0.1)


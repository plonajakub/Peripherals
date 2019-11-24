import RPi.GPIO as gpio
from time import *

gpio.setmode(gpio.BCM)
gpio.setwarnings(False)

gpio.setup(21, gpio.OUT)

while True:
	gpio.output(21, gpio.LOW)
	sleep(1)
	gpio.output(21, gpio.HIGH)
	sleep(1)

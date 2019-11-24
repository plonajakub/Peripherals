import RPi.GPIO as gpio
from time import *

gpio.setmode(gpio.BCM)
gpio.setwarnings(False)

gpio.setup(21, gpio.OUT)
gpio.setup(16, gpio.IN, pull_up_down=gpio.PUD_DOWN)

pushed = False

last_value = False
current_value = None

while True:
	current_value = gpio.input(16)
	if current_value and (not last_value):
		pushed = not pushed
		last_value = current_value
		gpio.output(21, pushed)
	else:
		last_value = False

	sleep(0.1)

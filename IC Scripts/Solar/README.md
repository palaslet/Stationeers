# Solar

This section contains different solar control scripts. The scripts are designed to automate solar control

## OneChipControl
Will control all Solar Panels from only one IC10 chip. No Batch Writer needed.
It controls both horizontal and vertical angels.

### Construction

List of parts needed:
* 1x [Integrated Circuit](https://stationeers-wiki.com/Integrated_Circuit_(IC10))
* 1x [IC Housing](https://stationeers-wiki.com/Kit_(IC_Housing))
* 1x [Daylight Sensor](https://stationeers-wiki.com/Sensors#Daylight_Sensor)
* 1x [Power Controller](https://stationeers-wiki.com/Power_Controller)
* Some [Cable Coil (Heavy)](https://stationeers-wiki.com/Cables)
* A [Computer](https://stationeers-wiki.com/Computer) with [IC Editor](https://stationeers-wiki.com/Motherboard)

The Daylight sensor must be pointing front side up, and top towards sunrise (cable connection towards sunset).
Solar panels must be mounted with power connector towards sunrise. I recommend using the model with both power and data on the same port.
The IC Housing should be connected with its data port to a cable connecting all Solar Panel data ports. If you're using combined ports (data & power in the same port), just connect the data side of the IC Housing straight to the power network.
Use a Power Controller to supply power for the IC Housing. This should not try to leech power off the Solar Panel power network since the house batteries will probably take all the power and not leave anything for the Power Controller.

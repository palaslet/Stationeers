# Atmospherics

This section contains different atmospherics scripts. The scripts are designed to automate different sections of the "Atmospherics Department"

## HeatingLoop

The current implementation (as of 05.08.2019) of the AC unit does not have D and I gain in it's power controller. The power is purely based on temperature difference (P gain). This results in it being very bad at holding target temperature in a gas loop. It also trottles way down when it approaches target temperature so it takes long to heat/cool any significant amount of gas.

The heating loop will use one AC to heat gasses to desired temperature and then transfer the gasses to an isolated holding tank or buffer. The buffer can then provide a source of constant temperature gas. Since the IC is controlling the loop, the AC can be set to target a temperature way higher than what we want and thus it will run on max power until the IC decides the target temperature is reached.

The Loop also operates at high pressures, ensuring maximum efficiency. Since it's aiming to run the AC at 7kW when heating, all electrical cabling related to this setup must be of the heavy type.

Finally, the AC "colant" port will be connected to our atmospheric waste network, so we will recycle some of the heat coming from funrnaces, greenhouses, etc. If our need is more about cooling, then a seperate cooling pipe can be created. Or, one could make the IC decide between two loops based on the needs.

### Construction

List of parts needed:
* 2x [Pipe Analyzer](https://stationeers-wiki.com/Pipe_Analyzer)
* 2x [Volume Pump](https://stationeers-wiki.com/Pipe_Volume_Pump)
* 1x [Air Conditioner](https://stationeers-wiki.com/Atmospherics#Air_Conditioner_Unit)
* 1x [Dial](https://stationeers-wiki.com/Kit_(Switch)#Dial)
* 1x [Tank Small](https://stationeers-wiki.com/Tank#Small_Tank)
* 1x [Integrated Circuit](https://stationeers-wiki.com/Integrated_Circuit_(IC10))
* 1x [IC Housing](https://stationeers-wiki.com/Kit_(IC_Housing))
* Some [Cable Coil (Heavy)](https://stationeers-wiki.com/Cables)
* Some [Pipes](https://stationeers-wiki.com/Pipes)
* A [Computer](https://stationeers-wiki.com/Computer) with [IC Editor](https://stationeers-wiki.com/Motherboard)

Piping schematic:
```
Input --- Volume Pump --- Air Conditioner --- Volume Pump --- Pipe Analyzer --- Small Tank
                       |                   |               |
                       --- Pipe Analyzer ---               --- Output (Pressure Regulator)
```

Setup:
1. Construct the structure according to above schematic.
2. Hook up the IC to the computer and program it using the [HeatingLoop.mips](https://github.com/palaslet/Stationeers/blob/master/IC%20Scripts/Atmospherics/HeatingLoop.mips) program.
3. Put the Dial in a nice spot (It's used to set the target temperature for the heating)
4. Connect the IC to the loop using only heavy cables. Make sure it has signal to all electrical devices in the loop.
5. Configure the IC so it has the correct device on the correct slot.
6. Set target temperature and start it up.
7. Isolate the buffer tank by building it inside a stage 3 iron frame. You can isolate the entire loop in this way, but it might be usefull to keep some of it accessible for monitoring purposes.

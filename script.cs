// R e a d m e
// -----------
// 
// In this file you can include any instructions or other comments you want to have injected onto the 
// top of your final script. You can safely delete this file if you do not want any such comments.
// 
        // This file contains your actual script.
        //
        // You can either keep all your code here, or you can create separate
        // code files to make your program easier to navigate while coding.
        //
        // Go to:
        // https://github.com/malware-dev/MDK-SE/wiki/Quick-Introduction-to-Space-Engineers-Ingame-Scripts
        //
        // to learn more about ingame scripts.

        public Program()
        {

            Runtime.UpdateFrequency = UpdateFrequency.Update10;
            // The constructor, called only once every session and
            // always before any other method is called. Use it to
            // initialize your script. 
            //     
            // The constructor is optional and can be removed if not
            // needed.
            // 
            // It's recommended to set Runtime.UpdateFrequency 
            // here, which will allow your script to run itself without a 
            // timer block.
        }

        public void Save()
        {
            // Called when the program needs to save its state. Use
            // this method to save your state to the Storage field
            // or some other means. 
            // 
            // This method is optional and can be removed if not
            // needed.
        }

       public void Main(string argument, UpdateType updateSource)
{
    // Get sensor group
    var sensorGroup = GridTerminalSystem.GetBlockGroupWithName("Sensors");
    if (sensorGroup == null)
    {
        Echo("No sensor group found.");
        return;
    }

    List<IMySensorBlock> sensors = new List<IMySensorBlock>();
    sensorGroup.GetBlocksOfType(sensors);

    // Check if any sensor is detecting something
    bool detected = sensors.Any(sensor => sensor.IsActive);

    // Get door group
    var doorGroup = GridTerminalSystem.GetBlockGroupWithName("Interior Doors");
    if (doorGroup == null)
    {
        Echo("No door group found.");
        return;
    }

    List<IMyDoor> doors = new List<IMyDoor>();
    doorGroup.GetBlocksOfType(doors);

    // Act based on detection
    if (detected)
    {
        Echo("Sensor triggered: opening doors.");
        foreach (var door in doors)
        {
            door.OpenDoor();
        }
    }
    else
    {
        Echo("No detection: closing doors.");
        foreach (var door in doors)
        {
            door.CloseDoor();
        }
    }
}

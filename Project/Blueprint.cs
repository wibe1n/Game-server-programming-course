using System.Collections.Generic;

namespace Project {

    public class Blueprint {
        public List<BlueprintPack> stations;
    }

    public class BlueprintPack {
        public string name;
        public int bikesAvailable;
    }
}
namespace ChangeMe
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class GameProgress
    {
        [DataMember]
        public int CurrentWorld { get; set; }
        [DataMember]
        public int CurrentLevel { get; set; }
        [DataMember]
        public int TotalMoves { get; set; }
        [DataMember]
        public GameItem[] GameItems { get; set; }
        [DataMember]
        public Dictionary<Int32, Int32> LevelsPuntuations { get; set; }
    }
}

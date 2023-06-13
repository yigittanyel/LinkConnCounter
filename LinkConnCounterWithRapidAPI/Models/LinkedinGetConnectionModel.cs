namespace LinkConnCounterWithRapidAPI.Models
{

    public class LinkedinGetConnectionModel
    {
        public Network_Info Network_Info { get; set; }
    }


    public class Network_Info
    {
        public int connections_count { get; set; }
        public bool followable { get; set; }
        public int followers_count { get; set; }
    }

}

public class Job
{
    public string id;
    public string type;
    public string urlParameters;
    public Answer answer;

    public Job(Dictionary<string,string> items)
    {
        this.id = items["id"];
        this.type = items["type"];
        switch(this.type)
        {
            case "DecodeStrand":
            {
                this.urlParameters = $"{this.id}/decode";
                break;
            }
            case "EncodeStrand":
            {
                this.urlParameters = $"{this.id}/encode";
                break;
            }
            case "CheckGene":
            {
                this.urlParameters = $"{this.id}/gene";
                break;
            }                
        }
    }
}
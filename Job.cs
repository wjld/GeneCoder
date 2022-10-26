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
                DNA dna = new DNA(items["strandEncoded"]);
                dna.Decode();
                DecodeAnswer answer = new DecodeAnswer();
                answer.strand = dna.GetStrand();
                this.answer = answer;
                break;
            }
            case "EncodeStrand":
            {
                this.urlParameters = $"{this.id}/encode";
                DNA dna = new DNA(items["strand"]);
                dna.Encode();
                EncodeAnswer answer = new EncodeAnswer();
                answer.strandEncoded = dna.GetStrand();
                this.answer = answer;
                break;
            }
            case "CheckGene":
            {
                this.urlParameters = $"{this.id}/gene";
                DNA dna = new DNA(items["strandEncoded"]);
                DNA gene = new DNA(items["geneEncoded"]);
                dna.Decode();
                gene.Decode();
                GeneAnswer answer = new GeneAnswer();
                answer.isActivated = dna.CheckGene(gene.GetStrand());
                this.answer = answer;
                break;
            }                
        }
    }
}
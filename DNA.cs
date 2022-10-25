class DNA
{
    string strand;

    static readonly Dictionary<string,char> bitsToChar = new Dictionary<string,char>
    {
        {"00",'A'},
        {"01",'C'},
        {"10",'G'},
        {"11",'T'},
    };

    static readonly Dictionary<char,string> charToBits = new Dictionary<char,string>
    {
        {'A',"00"},
        {'C',"01"},
        {'G',"10"},
        {'T',"11"},
    };

    static readonly Dictionary<char,char> complement = new Dictionary<char,char>
    {
        {'A','T'},
        {'C','G'},
        {'G','C'},
        {'T','A'},
    };

    public DNA(string strand)
    {
        this.strand = strand;
    }

    public string GetStrand()
    {
        return this.strand;
    }
}
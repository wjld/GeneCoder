using System.Text;

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

    bool IsMainStrand()
    {
        return strand.StartsWith("CAT");
    }

    void MainStrand()
    {
        StringBuilder generated = new StringBuilder();
        foreach(char c in strand)
        {
            generated.Append(complement[c]);
        }
        this.strand = generated.ToString();
    }

    public DNA(string strand)
    {
        this.strand = strand;
    }

    public string GetStrand()
    {
        return this.strand;
    }

    public void Decode()
    {
        StringBuilder decoded = new StringBuilder();
        foreach(byte part in Convert.FromBase64String(strand))
        {
            string bitString = Convert.ToString(part,2).PadLeft(8,'0');
            for(int i = 0; i <= bitString.Length - 2; i += 2)
            {
                decoded.Append(bitsToChar[bitString.Substring(i,2)]);
            }
        }
        this.strand = decoded.ToString();
    }

    public void Encode()
    {
        StringBuilder encoded = new StringBuilder();
        foreach(char c in strand)
        {
            encoded.Append(charToBits[c]);
        }
        int byteN = (int)Math.Ceiling(encoded.Length / 8f);
        string bitstring = encoded.ToString();
        byte[] arr = new byte[byteN];
        for(int i = 0; i < byteN; i++)
        {
            arr[i] = Convert.ToByte(bitstring.Substring(8 * i, 8), 2);
        }
        this.strand = Convert.ToBase64String(arr);
    }
}
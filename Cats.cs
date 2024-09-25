
public class Cat{

    public string type;
    public string like;
    public bool found = false;
    public int locationNum;
    public int hintNum;

    public Cat(string type, string like, int location, int hint){
        this.type = type;
        this.like = like;
        locationNum = location;
        hintNum = hint;
    }

    public override string ToString(){
        return "type: "+type+", likes: "+like+", at: "+locationNum+", hint at:"+hintNum;
    }

}
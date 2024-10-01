
public class Cat{

    public string type;
    public string like;
    public bool found = false;
    public int locationNum;
    public int hintNum;
    public int index;

    public Cat(string type, string like, int location, int hint, int index){
        this.type = type;
        this.like = like;
        locationNum = location;
        hintNum = hint;
        this.index = index;
    }

    public override string ToString(){
        return "type: "+type+", likes: "+like+", at: "+locationNum+", hint at:"+hintNum;
    }

}
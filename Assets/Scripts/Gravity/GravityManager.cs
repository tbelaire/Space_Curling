
public class GravityManager {
    private static GravityManager instanceInternal;
    public static GravityManager instance
    {
        get
        {
            if (instanceInternal == null)
            {
                instanceInternal = new GravityManager();
            }
            
            return instanceInternal;
        }
    }
    
    public void registerBody() {
    
    }
}

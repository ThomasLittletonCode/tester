

public class save{
   

    public static void main(String[] args) {
        
        Boolean test = false;
        String name = "test";
        String[] array = {"exampleName", "test", "testName"};
        for(int i = 0; i <= array.length-1; i++){

            String a = array[i];
            if(a == name){
                System.out.println("true " + i);
                test = true;
            }
            else if(a != name){
                System.out.println("false " + i);
            }

        }
        if(test == false){
            System.out.println("none");
        }
    }
}
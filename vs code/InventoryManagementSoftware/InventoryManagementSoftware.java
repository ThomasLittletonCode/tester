public class InventoryManagementSoftware {
    public static void main(String[] args) {
        int[] threeDPrinterAmount = {10, 1, 2, 2};
        String[] threeDPrinterMaterials = {"pla plus black", "pla black"};
        
        // Printing the array
        for (int i = 0; i < threeDPrinterAmount.length; i++) {
            System.out.print(threeDPrinterAmount[i] + " ");
        }
        
        // Example: Find and print the amount for a specific material
        String searchMaterial = threeDPrinterMaterials[1];  // material you want to search for
        for (int i = 0; i < threeDPrinterMaterials.length; i++) {
            if (threeDPrinterMaterials[i].equals(searchMaterial)) {
                System.out.println("Amount of " + searchMaterial + ": " + threeDPrinterAmount[i]);
            }
        }
    }
}

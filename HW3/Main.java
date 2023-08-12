package AlgorithmGB.HW3;

public class Main {
    public static void main(String[] args) {
        LinkedList list = new LinkedList();

        list.addElement(1);
        list.addElement(2);
        list.addElement(3);
        list.addElement(4);
        list.addElement(5);

        System.out.println("Оригинальный список:");
        list.print();

        list.reverse();

        System.out.println("Развернутый список:");
        list.print();
    }
}

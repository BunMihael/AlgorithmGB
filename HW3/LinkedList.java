package AlgorithmGB.HW3;

/**
 * Represents a singly linked list.
 */
public class LinkedList {
    private Node head;  // The head (start) of the linked list

    /**
     * Default constructor initializes the head as null.
     */
    public LinkedList() {
        this.head = null;
    }

    /**
     * Adds a new element to the end of the linked list.
     * @param data The data to add to the list.
     */
    public void addElement(int data) {
        Node newNode = new Node(data);

        // If the list is empty, make the new node the head
        if (head == null) {
            head = newNode;
        } else {
            Node current = head;
            // Traverse to the end of the list
            while (current.next != null) {
                current = current.next;
            }
            current.next = newNode;
        }
    }

    /**
     * Prints the linked list.
     */
    public void print() {
        Node current = head;
        while (current != null) {
            System.out.print(current.data + " -> ");
            current = current.next;
        }
        System.out.println("null");
    }

    /**
     * Reverses the linked list in-place.
     */
    public void reverse() {
        Node prev = null;
        Node current = head;
        Node next = null;

        while (current != null) {
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        head = prev;
    }
}

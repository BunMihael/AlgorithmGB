package AlgorithmGB.HW3;

/**
 * Represents a node in a singly linked list.
 */
public class Node {
    int data;   // Data stored in this node
    Node next;  // Reference to the next node in the list

    /**
     * Constructor to initialize the node with data.
     * @param data The data to store in this node.
     */
    public Node(int data){
        this.data = data;
        this.next = null;
    }
}

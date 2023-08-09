def sift_down(heap, index):
    max_index = index
    left_child_index = 2 * index + 1
    right_child_index = 2 * index + 2

    # Check the left child
    if left_child_index < len(heap) and heap[left_child_index] > heap[max_index]:
        max_index = left_child_index

    # Check the right child
    if right_child_index < len(heap) and heap[right_child_index] > heap[max_index]:
        max_index = right_child_index

    # If one of the children is greater than the current element, swap them
    if index != max_index:
        heap[index], heap[max_index] = heap[max_index], heap[index]
        sift_down(heap, max_index)

def build_max_heap(heap):
    for i in range((len(heap) - 2) // 2, -1, -1):
        sift_down(heap, i)

def heap_sort(heap):
    build_max_heap(heap)
    sorted_array = []
    for i in range(len(heap) - 1, -1, -1):
        # Swap the root element and the last element in the heap
        heap[0], heap[i] = heap[i], heap[0]
        # Add the maximum element to the sorted array
        sorted_array.insert(0, heap.pop())
        # Restore the heap property
        sift_down(heap, 0)
    return sorted_array

heap = [0, 3, 4, 1, 6, 7, 2, 4, 10]
sorted_array = heap_sort(heap)
print(sorted_array)  # Should print the sorted array: [0, 1, 2, 3, 4, 4, 6, 7, 10]

#pragma once

struct QueueElement;

struct Queue;

// Initialize the queue.
Queue* initQueue();

// Get size of the queue.
int getSize(Queue *queue);

// Add element to the tail of queue.
void enqueue(Queue *queue, int value);

// Delete element from the head of queue.
int dequeue(Queue *queue);

// Delete minimal element from the queue.
int dequeueMin(Queue *queue);

// Delete maximal element from the queue.
int dequeueMax(Queue *queue);

// Free memory.
void deleteQueue(Queue *queue);
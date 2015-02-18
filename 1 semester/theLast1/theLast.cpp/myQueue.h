#pragma once

struct QueueElement;

struct Queue;

Queue* initQueue();

int getSize(Queue *queue);

void enqueue(Queue *queue, int value);

int dequeue(Queue *queue);

void deleteQueue(Queue *queue);
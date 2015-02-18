#pragma once

struct QueueElement;

struct Queue;

void enqueue(Queue *queue, int value);

int dequeue(Queue *queue);
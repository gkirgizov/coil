#include "myQueue.h"

struct QueueElement
{
	int value;
	QueueElement *next = nullptr;
};

struct Queue
{
	QueueElement *head = nullptr;
	QueueElement *tail = nullptr;
};

Queue* initQueue()
{
	return new Queue;
}

int getSize(Queue *queue)
{
	int size = 0;
	QueueElement *cursor = queue->head;
	for (size; cursor != nullptr; ++size)
	{
		cursor = cursor->next;
	}
	return size;
}

void enqueue(Queue *queue, int value)
{
	QueueElement *newElement = new QueueElement;
	newElement->value = value;
	if (queue->tail != nullptr)
	{
		queue->tail->next = newElement;
	}
	else
	{
		queue->head = newElement;
	}
	queue->tail = newElement;
}

int dequeue(Queue *queue)
{
	if (queue->head == nullptr)
	{
		return 0; //error
	}
	if (queue->head == queue->tail)
	{
		int temp = queue->head->value;
		delete queue->head;
		queue->head = nullptr;
		queue->tail = nullptr;
		return temp;
	}
	int temp = queue->head->value;
	QueueElement *tempElement = queue->head->next;
	delete queue->head;
	queue->head = tempElement;
	return temp;
}

void deleteQueue(Queue *queue)
{
	while (queue->head != nullptr)
	{
		QueueElement *tempElement = queue->head;
		queue->head = queue->head->next;
		delete tempElement;
	}
}
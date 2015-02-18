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
	if (queue->head = queue->tail)
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

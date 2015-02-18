//ОЧЕРЕДИ И СТЕКИ
//
//ОЧЕРЕДЬ(queue)

//enqueue(q, x); - добавить элемент
//dequeue(q); - удалить элемент
//
//Реализуется в виде двух курсоров - head и tail

struct QueueElement{
	int value;
	QueueElement *next = nullptr; //можно сразу проинициализировать чтобы потом не делать
};

struct Queue{
	QueueElement *head = nullptr; //снова сразу проинициализируем
	QueueElement *tail = nullptr; //снова сразу проинициализируем
};

void enqueue(Queue *queue1, int value)
{
	QueueElement *newElement = new QueueElement;
	newElement->value = value;
	if (queue1->tail != nullptr)
	{
		queue1->tail->next = newElement;
	}
	else
	{
		queue1->head = newElement;
	}
	queue1->tail = newElement;
}

int dequeue(Queue *queue1)
{
	if (queue1->head == nullptr)
	{
		return -1; //error
	}
	if (queue1->head = queue1->tail)
	{
		//нужно обнулять указатели если больше не нужно использовать,
		//но перед этим нужно удалить сам элемент
		int temp = queue1->head->value;
		delete queue1->head;
		queue1->head = nullptr;
		queue1->tail = nullptr;
		return temp;
	}
	int temp = queue1->head->value;
	QueueElement *tempptr = queue1->head->next;
	delete queue1->head;
	queue1->head = queue1->head->next;
	return temp;
}

//СТЕК
	/*Как считывать обратную польскую запись:
	если видим число то добавляем на стек
	если видим оператор то снимаем два числа со стека 
	и записываем результат на стек
	в конце концов на стеке остается одно число - это и есть ответ*/

//стек позволяет обходить некую структуру данных в глубину
//а очередь - в ширину
//������� � �����
//
//�������(queue)

//enqueue(q, x); - �������� �������
//dequeue(q); - ������� �������
//
//����������� � ���� ���� �������� - head � tail

struct QueueElement{
	int value;
	QueueElement *next = nullptr; //����� ����� ������������������� ����� ����� �� ������
};

struct Queue{
	QueueElement *head = nullptr; //����� ����� �����������������
	QueueElement *tail = nullptr; //����� ����� �����������������
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
		//����� �������� ��������� ���� ������ �� ����� ������������,
		//�� ����� ���� ����� ������� ��� �������
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

//����
	/*��� ��������� �������� �������� ������:
	���� ����� ����� �� ��������� �� ����
	���� ����� �������� �� ������� ��� ����� �� ����� 
	� ���������� ��������� �� ����
	� ����� ������ �� ����� �������� ���� ����� - ��� � ���� �����*/

//���� ��������� �������� ����� ��������� ������ � �������
//� ������� - � ������
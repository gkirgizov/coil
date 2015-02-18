//Структуры
#include <iostream>

struct Point {
	int x;
	int y;
};

struct ListElement {
	int value;
	//структура времени компиляции
	ListElement *next;
};

void main()
{
	//память на стеке
	Point point1;
	point1.x = 10;
	point1.y = 20;

	//память на куче - нужно удалять
	Point *point2 = new Point();
	//если через указатели - то нужно писать стрелочку(это доступ к полю) ->
	point2->x = 10; 
	point2->y = 20;
	//Ё указатель лежит на стеке, но значение - в куче



	//структура времени выполнения
	ListElement *lstElmnt1 = new ListElement();
	lstElmnt1->value = 1;
	lstElmnt1->next = nullptr;

	ListElement * lstElmnt2 = new ListElement();
	lstElmnt2->value = 2;
	lstElmnt2->next = nullptr;

	lstElmnt1->next = lstElmnt2;
}


//Циклические структуры

struct List1;

struct List2 {
	List2 *head;
};

struct List1 {
	List1 *next;
	List2 *lst2;
};



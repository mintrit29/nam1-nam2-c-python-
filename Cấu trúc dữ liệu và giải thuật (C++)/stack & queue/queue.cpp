#include <iostream>
using namespace std;

struct node
{
    int data;
    node *next;
};

node *makeNode(int x)
{
    node *newNode = new node();
    newNode->data = x;
    newNode->next = NULL;
    return newNode;
}

void push(node *&queue, int x)
{
    node *newNode = makeNode(x);
    if (queue == NULL)
    {
        queue = newNode;
        return;
    }
    node *temp = queue;
    while (temp->next != NULL)
    {
        temp = temp->next;
    }
    temp->next = newNode;
}

void pop(node *&queue)
{
    if (queue == NULL)
        return;
    node *temp = queue;
    queue = queue->next;
    delete temp;
}

int size(node *queue)
{
    int ans = 0;
    while (queue != NULL)
    {
        ++ans;
        queue = queue->next;
    }
    return ans;
}

bool empty(node *&queue)
{
    return queue == NULL;
}

int front(node *queue)
{
    return queue->data;
}

void duyet(node *queue)
{
    while (queue != NULL)
    {
        cout << queue->data << " ";
        queue = queue->next;
    }
}

int main()
{
    node *queue = NULL;
    int choice;
    do
    {
        cout << "\n---Menu---\n";
        cout << "1. push \n";
        cout << "2. pop \n";
        cout << "3. front \n";
        cout << "4. size \n";
        cout << "5. empty \n";
        cout << "6. duyet \n";
        cout << "Nhap vao lua chon cua ban: ";
        cin >> choice;
        switch (choice)
        {
        case 0:
            cout << "Da thoat chuong trinh.\n";
            break;
        case 1:
            int x;
            cin >> x;
            push(queue, x);
            break;
        case 2:
            pop(queue);
            break;
        case 3:
            cout << front(queue) << endl;
            break;
        case 4:
            cout << size(queue) << endl;
            break;
        case 5:
            if (empty(queue))
                cout << "EMPTY\n";
            else
                cout << "NOT EMPTY\n";
            break;
        case 6:
        {
            duyet(queue);
            break;
        }
        }
    } while (choice != 0);
}
// doi so thap phan sang nhi phan duoi dang stack

#include <iostream>
using namespace std;

struct Node
{
    int data;
    Node *next;
};

Node *makeNode(int x)
{
    Node *newNode = new Node();
    newNode->data = x;
    newNode->next = NULL;
    return newNode;
}

void PushNode(Node *&top, int x)
{
    Node *newNode = makeNode(x);
    newNode->next = top;
    top = newNode;
}

void PopNode(Node *&top)
{
    if (top == NULL)
        return;
    Node *temp = top;
    top = top->next;
    delete temp;
}

void PrintNode(Node *&top)
{
    while (top != NULL)
    {
        cout << top->data << " ";
        top = top->next;
    }
}

int main()
{
    int n;
    cin >> n;
    Node *top = NULL;
    while (n != 0)
    {
        int x = n % 2;
        PushNode(top, x);
        n = n / 2;
    }
    PrintNode(top);
    return 0;
}
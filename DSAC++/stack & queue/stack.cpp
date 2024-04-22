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

void push(node *&top, int x)
{
    node *newNode = makeNode(x);
    newNode->next = top;
    top = newNode;
}

void pop(node *&top)
{
    if (top != NULL)
    {
        node *temp = top;
        top = temp->next;
        delete temp;
    }
}

int top(node *top)
{
    if (top != NULL)
        return top->data;
    else
        return false;
}

int size(node *top)
{
    int ans = 0;
    while (top != NULL)
    {
        ++ans;
        top = top->next;
    }
    return ans;
}

void duyet(node *top)
{ // duyet qua danh sach tra ve data
    while (top != NULL)
    {
        cout << top->data << " ";
        top = top->next;
    }
}

int main()
{
    node *stack = NULL;
    int choice;
    do
    {
        cout << "\n---Menu---\n";
        cout << "1. push \n";
        cout << "2. pop \n";
        cout << "3. top \n";
        cout << "4. size \n";
        cout << "5. duyet \n";
        cout << "Nhap vao lua chon cua ban: ";
        cin >> choice;
        switch (choice)
        {
        case 0:
            cout << "Da thoat chuong trinh.\n";
            break;
        case 1:
            int x;
            cout << "Nhap x: ";
            cin >> x;
            push(stack, x);
            break;
        case 2:
            pop(stack);
            break;
        case 3:
            if (stack != NULL)
                cout << top(stack) << endl;
            else
                cout << "Emty\n";
            break;
        case 4:
            cout << size(stack) << endl;
            break;
        case 5:
        {
            duyet(stack);
            break;
        }
        }
    } while (choice != 0);
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryApp
{
    // Linked list class
    class LinkedList
    {
        // Class: Node
        // Represent node objects in linked lists
        private class Node
        {
            // website in the list
            public string website;
            public Node next;


            // Default constructor
            public Node()
            {
                next = null;
            }

            // Parameterized constructor
            public Node(string key)
            {
                website = key;
                next = null;
            }
        }

        // First node in the list
        private Node head;

        // Insert a node at the end
        public void insertAtEnd(string input)
        {
            if (isEmpty())
                head = new Node(input);
            else
            {
                Node current = head;

                // traverse to the end of the list
                while(current.next != null)
                    current = current.next;

                // perform the insertion 
                current.next = new Node(input);
            }
        }

        // Return the website of the last node
        // in the linked list
        public string getLastNode()
        {
            if (isEmpty())
                return null;
            else if (head != null && head.next == null)
                return head.website;
            else
            {
                Node current = head;

                // Identify the last node
                while (current.next != null)
                    current = current.next;

                // Return the website
                return current.website;
            }
        }

        // Check if the list is empty and return true
        // if the list doesn't contain any nodes
        public bool isEmpty()
        {
            return (head == null);
        }

        // Delete the last node in the linked list
        public void deleteLastNode()
        {

            if (isEmpty()) // First case: empty list
                return;
            else if(head != null && head.next == null)
            {
                // Second case: only one node exists
                head = null;
            }
            else // Third case: multiple nodes exist
            {
                Node current = head;

                // Traverse to the last node
                while (current.next.next != null)
                    current = current.next;

                // Deletion
                current.next = null;
            }
        }

        // Output the entire list
        public void outputList()
        {
            // start at the first node
            Node current = head;

            // for each node that's not null, 
            // output the website and
            // proceed to the next node
            while(current != null)
            {
                if(current != null)
                    Console.WriteLine(current.website);
                current = current.next;
            }
        }
    }

    class BrowserHistory
    {
        // Browser History requres 2 lists
        // One for pages to visit in the future
        // One for pages visited in the past
        private LinkedList FuturePages;
        private LinkedList PreviousPages;

        // Constructor
        // Just initialize the two linked lists
        public BrowserHistory()
        {
            FuturePages = new LinkedList();
            PreviousPages = new LinkedList();
        }

        // outputHistory()
        // output both linked lists
        public void outputHistory()
        {
            Console.WriteLine("Previously visited pages:");
            PreviousPages.outputList();
            Console.WriteLine("Pages in your 'future':");
            FuturePages.outputList();
        }

        // moveBackwards()
        // Identify the final page in the previous pages list
        // Add it to the future pages list
        public void moveBackwards()
        {
            string temp = PreviousPages.getLastNode();
            PreviousPages.deleteLastNode();
            FuturePages.insertAtEnd(temp);
        }

        // moveBackwards()
        // Exact opposite behavior of the moveBackwards() function
        // Identify the final page in the future pages list
        // Add it to the orevious pages list
        public void moveForwards()
        {
            string temp = FuturePages.getLastNode();
            FuturePages.deleteLastNode();
            PreviousPages.insertAtEnd(temp);
        }

        // visitNewPage()
        // Add a new page to the previous pages list
        public void visitNewPage(string page)
        {
            PreviousPages.insertAtEnd(page);
        }
        
        // outputMenu()
        // 5 user options for the main program
        public void outputMenu()
        {
            Console.WriteLine("Your options are:");
            Console.WriteLine("1) View your history");
            Console.WriteLine("2) Move 1 page backwards in your 'browser history'");
            Console.WriteLine("3) Move 1 page forwards in your 'browser history'");
            Console.WriteLine("4) Visit a new page");
            Console.WriteLine("5) Quit");
        }

        // userInterface()
        // The function users utilize to update their browser history
        // in any way they wish
        public void userInterface()
        {
            // prompt the user to select an option
            outputMenu();

            int option;

            // As long as the user selects a valid option
            while(Int32.TryParse(Console.ReadLine(), out option) == true)
            {
                // if the user chooses to quit, the program ends its run
                if (option == 5)
                    break;
                else if (option == 1)
                {
                    outputHistory();
                    outputMenu();
                }
                else if (option == 2)
                {
                    moveBackwards();
                    outputMenu();
                }
                else if (option == 3)
                {
                    moveForwards();
                    outputMenu();
                }
                else if(option == 4)
                {
                    Console.WriteLine("What page are you visiting?");

                    string page = Console.ReadLine();

                    visitNewPage(page);
                    outputMenu();
                }
                else // if the user selects anything but numbers from 1 to 5
                {
                    // Notify the user and prompt him/her to re-enter 
                    // a valid input every time
                    Console.WriteLine("Invalid input");
                    outputMenu();
                }

            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            BrowserHistory bh = new BrowserHistory();
            bh.userInterface();
        }
    }
}

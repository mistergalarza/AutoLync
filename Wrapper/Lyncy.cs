using Microsoft.Lync.Model;
using Microsoft.Lync.Model.Conversation;
using Microsoft.Lync.Model.Extensibility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoLync.Wrapper
{
    public class Lyncy
    {
        ConversationService service;
        LyncClient client;

        List<Conversation> currentConversations;

        public Lyncy()
        {
            client = LyncClient.GetClient();
            currentConversations = new List<Conversation>();
        }

        public void Start()
        {
            client.ConversationManager.ConversationAdded += ConversationManager_ConversationAdded;
            client.StateChanged += client_StateChanged;

            client.Self.Contact.ContactInformationChanged += Contact_ContactInformationChanged;
        }

        public void Stop()
        {
            
        }

        private void ConversationManager_ConversationAdded(object sender, ConversationManagerEventArgs e)
        {
            service = new ConversationService(e.Conversation);
            service.Start();
            service.MessageReceived += Service_MessageReceived;
        }

        private void Contact_ContactInformationChanged(object sender, ContactInformationChangedEventArgs e)
        {
            Contact contact = sender as Contact;
            if (contact == null) return;

            if (e.ChangedContactInformation.Contains(ContactInformationType.Availability))
            {
                ContactAvailability availability = (ContactAvailability)contact.GetContactInformation(ContactInformationType.Availability);

                if (availability != ContactAvailability.Free)
                {
                    Cursor.Current = new Cursor(Cursor.Current.Handle);
                    Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void Service_MessageReceived(string message, string participantName, InstantMessageModality instantMessageModality)
        {
            // TODO: Handle logic for replying if anything
            throw new NotImplementedException();
        }

        private void client_StateChanged(object sender, ClientStateChangedEventArgs e)
        {
            // TODO: Do something when state changes
            throw new NotImplementedException();
        }
    }
}

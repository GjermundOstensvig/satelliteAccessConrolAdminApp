using System;
using System.Collections.ObjectModel;
using System.Data;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SatelliteAccessControlAdmin
{
    public sealed partial class MainPage : Page
    {
        DatabaseHandler database;
        ObservableCollection<person> persons = new ObservableCollection<person>();
        ObservableCollection<room> rooms = new ObservableCollection<room>();
        public MainPage()
        {
            this.InitializeComponent();
            database = new DatabaseHandler();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddPersonFeedbackTB.Text = "Inserting person into database";
            database.insertPerson(FNameTB.Text, LNameTB.Text, EMailTB.Text, PhoneNumTB.Text);
            AddPersonFeedbackTB.Text = database.DbState;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DeletePersonFeedbackTB.Text = "Delete button was pressed.";
            if (DeleteListView.SelectedIndex == -1)
            {
                DeletePersonFeedbackTB.Text = "You have to choose a person to delete him/her.";
            }
            else
            {
                DeletePersonFeedbackTB.Text =  "Attempting to delete " + persons[DeleteListView.SelectedIndex].FirstName.ToString();
                database.deletePerson(persons[DeleteListView.SelectedIndex].PersonId);
                DeletePersonFeedbackTB.Text = database.DbState;
            }
        }

        private void UpdatePersonListBtn_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtbl = database.selectPersons();
            persons.Clear();
            foreach (DataRow row in dtbl.Rows)
            {
                person person = new person(row["PersonId"].ToString(),row["FirstName"].ToString(),row["LastName"].ToString(), row["E-Mail"].ToString(), row["PhoneNumber"].ToString());
                persons.Add(person);
            }
            DeleteListView.ItemsSource = persons;
        }

        private void UpdateAuthPersonListBtn_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtbl = database.selectPersons();
            persons.Clear();
            foreach (DataRow row in dtbl.Rows)
            {
                person person = new person(row["PersonId"].ToString(), row["FirstName"].ToString(), row["LastName"].ToString(), row["E-Mail"].ToString(), row["PhoneNumber"].ToString());
                persons.Add(person);
            }
            AuthorizeListView.ItemsSource = persons;
        }

        private void UpdateAuthRoomListBtn_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtbl = database.selectRooms();
            rooms.Clear();
            foreach (DataRow row in dtbl.Rows)
            {
                room room = new room(row["RoomNumber"].ToString(), row["Floor"].ToString());
                rooms.Add(room);
            }
            AuthorizeForRoomListView.ItemsSource = rooms;
        }

        private void GiveAccessBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorizeListView.SelectedIndex == -1 || AuthorizeForRoomListView.SelectedIndex == -1)
            {
                GiveAccessFeedbackTB.Text = "You must pick a person and a room to give access";
            }
            else
            {
                person person = persons[AuthorizeListView.SelectedIndex];
                room room = rooms[AuthorizeForRoomListView.SelectedIndex];
                database.insertAuthorization(person.PersonId.ToString() ,room.RoomNumber.ToString(), FormatDateTime(GiveAccessDatePicker.Date.DateTime), FormatDateTime(DateTime.Now));
            }
        }

        private string FormatDateTime(DateTime dateTime)
        {
            string formatedDT = dateTime.Year.ToString() + "-" + dateTime.Month.ToString() + "-" + dateTime.Day.ToString() + " " +
                dateTime.Hour.ToString() + ":" + dateTime.Minute.ToString() + ":" + dateTime.Second.ToString();
            return formatedDT;
        }
    }
}

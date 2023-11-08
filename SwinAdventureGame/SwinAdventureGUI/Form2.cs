using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using SwinAdventure;

namespace SwinAdventureGUI
{
    public partial class Form2 : Form
    {
        //Create the objects of the game:
        Player player;
        Location hall, garden, lab;
        Path pathHtoL, pathHtoG, pathGtoH, pathGtoL, pathLtoH, pathLtoG;
        CommandProcessor command;
        Item shovel, sword, gem, pc, rope, scope, goggles, coat;
        Bag bag, cart, handbag;


        public Form2()
        {
            InitializeComponent();
            locationInvLabel.Visible = false;
            locInvInfoLabel.Visible = false;
            pInvInfoLabel.Visible = false;
            playerInvLabel.Visible = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //getting the name and description of the player from the login form
            String playerName = LoginForm.passingName;
            String playerDesc = LoginForm.passingDesc;
            player = new Player(playerName, playerDesc);

            SetupGame();

            player.Location = hall;

            //print welcome message
            outputLabel.Text = "Welcome to SwinAdventure, " + player.Name + "!\n" + "You have arrived in the " + player.Location.Name;
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            locationInvLabel.Visible = true;
            locInvInfoLabel.Visible = true;
            pInvInfoLabel.Visible = true;
            playerInvLabel.Visible = true;

            //strings to handle input from user (command)
            string reply, userCommand;
            string[] commandArr;

            //Validate input
            userCommand = commandTextBox.Text; //getting the command from the user
            if (String.IsNullOrEmpty(userCommand))
            {
                MessageBox.Show("Enter your command");
            }
            else
            {
                commandArr = new[] { userCommand }; //converting into string[] array
                commandArr = userCommand.Split(" "); //splitting the command based on spaces between words

                reply = command.Execute(player, commandArr); //executing command using command processor
                outputLabel.Text = reply;

                //checking if the player wants to quit
                //quit command returns Good bye
                if (reply.ToLower() == "good bye")
                {
                    MessageBox.Show(reply);
                    this.Hide();
                    Application.Exit();
                }
            }

            //displaying the player inventory and location invnetory and exits for refernce
            pInvInfoLabel.Text = player.Name + "'s Inventory";
            playerInvLabel.Text = player.Inventory.ItemList;
            locInvInfoLabel.Text = player.Location.Name + "'s Description";
            locationInvLabel.Text = player.Location.FullDescription;

            commandTextBox.Text = String.Empty; //clear the textbox
        }

        void SetupGame()
        {
            //Add locations
            hall = new Location(new string[] { "hallway" }, "Hallway", "This is a long well lit Hallway");

            garden = new Location(new string[] { "garden" }, "Garden", "This is a big garden with a lot of secret spots");

            lab = new Location(new string[] { "lab" }, "Laboratory", "This is where the magic is created");

            //Setup the paths
            pathHtoL = new Path(new string[] { "south", "s", "down" }, "South", "slide", lab);
            pathHtoG = new Path(new string[] { "east", "e", "right" }, "East", "small door", garden);

            pathGtoH = new Path(new string[] { "west", "w", "left" }, "West", "small door", hall);
            pathGtoL = new Path(new string[] { "sw", "south_west" }, "South West", "roller coaster", lab);

            pathLtoH = new Path(new string[] { "n", "north", "up" }, "North", "ladder", hall);
            pathLtoG = new Path(new string[] { "ne", "north_east" }, "North East", "roller coaster", garden);

            //Add the paths to each location
            hall.AddPath(pathHtoG);
            hall.AddPath(pathHtoL);

            garden.AddPath(pathGtoL);
            garden.AddPath(pathGtoH);

            lab.AddPath(pathLtoG);
            lab.AddPath(pathLtoH);

            //Create the items
            shovel = new Item(new string[] { "shovel" }, "shovel", "This is a might fine shovel");
            sword = new Item(new string[] { "sword" }, "bronze sword", "This is a shiny sword");
            gem = new Item(new string[] { "gem" }, "red gem", "This is a shiny red gem");
            pc = new Item(new string[] { "pc" }, "small computer", "This is a computer from the future");
            rope = new Item(new string[] { "rope" }, "rope", "This is the strongest rope ever");
            scope = new Item(new string[] { "scope" }, "hand scope", "This is a golden scope with x1000 magnification");
            goggles = new Item(new string[] { "goggles" }, "IR goggles", "These are the best night vision goggles");
            coat = new Item(new string[] { "coat" }, "lab coat", "This is a white lab coat");

            //Create the bags
            bag = new Bag(new string[] { "bag" }, "plastic bag", "This is a clear plastic bag");
            cart = new Bag(new string[] { "cart" }, "gardening cart", "This is a big gardening cart that fits large items");
            handbag = new Bag(new string[] { "handbag" }, "handbag", "This is a leather handbag");

            //Setup the game by adding items to locations and bags
            hall.Inventory.Put(sword);
            handbag.Inventory.Put(gem);
            hall.Inventory.Put(handbag);

            garden.Inventory.Put(scope);
            garden.Inventory.Put(rope);
            cart.Inventory.Put(shovel);
            garden.Inventory.Put(cart);

            lab.Inventory.Put(coat);
            lab.Inventory.Put(pc);
            bag.Inventory.Put(goggles);
            lab.Inventory.Put(bag);

            command = new CommandProcessor();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

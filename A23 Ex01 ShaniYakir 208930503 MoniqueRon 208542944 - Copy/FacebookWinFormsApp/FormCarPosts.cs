using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.IO;
using Newtonsoft.Json;



namespace BasicFacebookFeatures
{
    public partial class FormCarPosts : Form
    {
        JsonPosts m_CarsPosts = new JsonPosts();
        JsonPost m_PostCarItem = new JsonPost();

        public FormCarPosts(List<JsonPost> listOfCarPosts)
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 200;
            m_CarsPosts.jsonPostsList = sortPostList(listOfCarPosts);
        }


        private void listPostsByFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            listPostsByFilter_SelectedValueChanged(sender, e);

        }

        private List<JsonPost> sortPostList(List<JsonPost> lst)
        {
            List<JsonPost> SortedList = lst.OrderBy(o => o.PostDate).ToList();
            return SortedList;
        }

        private void GroupsByFilterForm_Load(object sender, EventArgs e)
        {
            listPostsByFilterBox.Items.Clear();
            listPostsByFilterBox.DisplayMember = "Post";
            foreach (JsonPost post in m_CarsPosts.jsonPostsList)
            {
                listPostsByFilterBox.Items.Add(post.PostText);
            }
        }

        private void listPostsByFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listPostsByFilterBox.SelectedIndex != -1)
            {
                var itemIndex = listPostsByFilterBox.SelectedIndex;
                m_PostCarItem = m_CarsPosts.getItemByIndex(itemIndex);
                richTextBox2.Text = m_PostCarItem.toString();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
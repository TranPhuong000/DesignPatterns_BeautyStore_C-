using BeautyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace BeautyStore.DesignPattern
{
    public class CustomerBuilder
    {
        private string _userName;
        private string _userEmail;
        private string _phoneNumber;
        private string _userPassword;
        private string _avatarImage;
        
        //set giá trị cho username và trả vè cho đối tượng builder
        public CustomerBuilder WithUserName(string userName)
        {
            _userName = userName;
            return this;
        }
        //set giá trị cho email và trả vè cho đối tượng builder
        public CustomerBuilder WithUserEmail(string userEmail)
        {
            _userEmail = userEmail;
            return this;
        }
        //set giá trị cho số điện thoại và trả vè cho đối tượng builder

        public CustomerBuilder WithPhoneNumber(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
            return this;
        }
        //set giá trị cho pass và trả vè cho đối tượng builder

        public CustomerBuilder WithUserPassword(string userPassword)
        {
            _userPassword = userPassword;
            return this;
        }
        //set giá trị cho hình ảnh và trả vè cho đối tượng builder

        public CustomerBuilder WithAvatarImage(string avatarImage)
        {
            _avatarImage = avatarImage;
            return this;
        }
        //Tạo đối tượng user với các thuộc tính và trả về cho đối tượng builder
        public Customer Build()
        {
            return new Customer
            {
                UserName = _userName,
                UserEmail = _userEmail,
                PhoneNumber = _phoneNumber,
                UserPassword = _userPassword,
                AvatarImage = _avatarImage,
            };
        }
    }
}

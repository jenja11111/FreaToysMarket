using FreaToysMarket.Data.Interfaces;
using FreaToysMarket.Data.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreaToysMarket.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {

        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            uint allPrice = 0;

            appDBContent.SaveChanges();

            var items = shopCart.listShopItems;

            foreach (var el in items)
            {
                allPrice += el.item.price;
                var orderDetail = new OrderDetail()
                {
                    ItemID = el.item.id,
                    OrderID = order.Id,
                    Price = el.item.price
                };
                
                appDBContent.OrderDetail.Add(orderDetail);
            }
            try
            {
                SmtpClient mySmtpClient = new SmtpClient("smtp.gmail.com", 587);

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                mySmtpClient.EnableSsl = true;

                mySmtpClient.Credentials = new NetworkCredential("FreaToysMarket@gmail.com", "FreaToysMarketPassword");

                // add from,to mailaddresses
                MailAddress from = new MailAddress(order.Adress, "Заказчик " + order.Name);
                MailAddress to = new MailAddress("FreaToysMarket@gmail.com", "Продавец");
                MailMessage myMail = new MailMessage(from, to);

                // add ReplyTo
                MailAddress replyTo = new MailAddress(order.Adress);
                myMail.ReplyToList.Add(replyTo);

                // set subject and encoding
                myMail.Subject = "Заказ №" + order.Id;
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = "Здравствуйте, меня зовут " + order.Name + " " + order.Surname 
                    + "! Я бы хотел у вас приобрести товар(ы) на сумму: " + allPrice + " рублей.\nВот мой номер телефона для связи: " + order.Phone 
                    + ".\nВремя заказа: " + order.OrderTime + ".\nЖду обратного звонка для согласования!";
                myMail.BodyEncoding = System.Text.Encoding.UTF8;

                // text or html
                myMail.IsBodyHtml = false;

                mySmtpClient.Send(myMail);
            }

            catch (SmtpException ex)
            {
                throw new ApplicationException
                  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            appDBContent.SaveChanges();
        }
    }
}

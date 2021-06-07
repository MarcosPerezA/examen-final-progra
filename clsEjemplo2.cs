using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using System.Data.SqlTypes;
using System.Data.SqlClient;
 

namespace Progra1Bot.Clases
{
   public  class clsEjemplo2
    {
        private static TelegramBotClient Bot;

        public  async Task IniciarTelegram()
        {
            Bot = new TelegramBotClient("1822118500:AAH5kFVKryNfTdy0arla_QU6JQz0FeZt9V8");
           
            var me = await Bot.GetMeAsync();
            Console.Title = me.Username;

            Bot.OnMessage += BotCuandoRecibeMensajes;
            Bot.OnMessageEdited += BotCuandoRecibeMensajes;
            Bot.OnReceiveError += BotOnReceiveError;

            Bot.StartReceiving(Array.Empty<UpdateType>());
            Console.WriteLine($"escuchando solicitudes del BOT @{me.Username}");

           

            Console.ReadLine();
            Bot.StopReceiving();
        }

        // cuando recibe mensajes
        private static async void BotCuandoRecibeMensajes(object sender, MessageEventArgs messageEventArgumentos)
        {
            var ObjetoMensajeTelegram = messageEventArgumentos;
            var mensajes = ObjetoMensajeTelegram.Message;

            string mensajeEntrante = mensajes.Text;


            string respuesta = "No te entiendo";
            if (mensajes == null || mensajes.Type != MessageType.Text)
                return;

            Console.WriteLine($"Recibiendo Mensaje del chat {ObjetoMensajeTelegram.Message.Chat.Id}.");
            Console.WriteLine($"Dice {ObjetoMensajeTelegram.Message.Text}.");
           





            //tolower
            if (mensajes.Text.Contains("Hola"))
            {
                respuesta = "Hola me da mucho gusto de Saludarte!!!\n" + " Elige una opcion\n "+ " 1.Marcas de Dispositvos\n"+ " 2.Servicios\n"+ " 3.Donde estamos Ubicados";

                // respuesta = " 1.Marcas de Dispositvos";
                //respuesta = " 2.Servicios";
                //respuesta = " 3.Donde estamos Ubicados";
                //


            }

            if (mensajes.Text.Contains("1"))
            {
                respuesta = "Marcas Disponibles : Apple , Samsung ,Xiaomi";
            }

            if (mensajes.Text.Contains("2"))
            {
                respuesta = "Te Ofrecemos los siguientes servicios: Cambio de Pantalla para Apple: Iphone Xs Q1000, Iphone 11 Pro y Pro Max Q1500,Iphone 12 Pro y Pro Max Q2000 \n"+ "Cambio de Bateria:Iphone Xs Q500, Iphone 11 Pro y Pro Max Q600,Iphone 12 Pro y Pro Max Q600 \n" +"Cambio de pantalla :xiaomi miNote 10 Q500, Xiaomi MI 11 Q450 \n" +  " Cambio de pantalla : Samsung S21 Q2500, Samsung Note 20 Q 2750"; 
            }
            if (mensajes.Text.Contains("3"))
            {
                respuesta = "Nuestras sucursales son : Metro Plaza Jutiapa , El Progreso Jutiapa , Monjas Jalapa ";
            }
            if (mensajes.Text.Contains("Apple"))
            {
                respuesta = "Dispositivos Disponibles :011)Iphone Xs Q3500, 015)Iphone 11 Pro Q 5000 , 018)Iphone 11 Pro Max Q6500, \n eliga el codigo del dispositivo que desea comprar" ;
               
            }
            if (mensajes.Text.Contains("011"))
            {
                respuesta = "Tu total es de Q3500" + "¿desea pagar en efectivo o tarjeta?";
            }
            if (mensajes.Text.Contains("015"))
            {
                respuesta = "Tu total es de Q5000" + "¿desea pagar en efectivo o tarjeta?";
            }
            if (mensajes.Text.Contains("018"))
            {
                respuesta = "Tu total es de Q6500"+"¿desea pagar en efectivo o tarjeta?";
            }
            if (mensajes.Text.Contains("efectivo")){
                respuesta = "Puede recoger y pagar su dispositivo en nuestras sucursales: Metro Plaza Jutiapa , El Progreso Jutiapa , Monjas Jalapa ";

            }
            if (mensajes.Text.Contains("Tarjeta"))
            {
                respuesta = "ingrese su nombre, el numero de su tarjeta y su direccion y nosotros le enviaremos su pedido";
               

            }
            if (mensajes.Text.Contains("Samsung"))
            {
                respuesta = "Dispositivos Disponibles :012) Samsung S21 Q9500, 014) Samsung Note 20 Q 10000";
            }

            if (mensajes.Text.Contains("Xiaomi"))
            {
                respuesta = "Dispositivos Disponibles :016) xiaomi miNote 10 Q5000, 019) Xiaomi MI 11 Q6000";
            }
            if (mensajes.Text.Contains("012"))
            {
                respuesta = "Tu total es de Q9500" + "¿desea pagar en efectivo o tarjeta?";
            }
            if (mensajes.Text.Contains("014"))
            {
                respuesta = "Tu total es de Q10000" + "¿desea pagar en efectivo o tarjeta?";
            }
            if (mensajes.Text.Contains("016"))
            {
                respuesta = "Tu total es de Q5000" + "¿desea pagar en efectivo o tarjeta?";
            }
            if (mensajes.Text.Contains("019"))
            {
                respuesta = "Tu total es de Q6000" + "¿desea pagar en efectivo o tarjeta?";
            }
       










                if (!String.IsNullOrEmpty(respuesta))//    
            {
                await Bot.SendTextMessageAsync(
                    chatId: ObjetoMensajeTelegram.Message.Chat,
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                    text: respuesta

            );
            }

        } // fin del metodo de recepcion de mensajes



        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Console.WriteLine("UPS!!! Recibo un error!!!: {0} — {1}",
                receiveErrorEventArgs.ApiRequestException.ErrorCode,
                receiveErrorEventArgs.ApiRequestException.Message
            );
        }


    }
}

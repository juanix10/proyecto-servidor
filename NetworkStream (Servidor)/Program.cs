/*
 * Created by SharpDevelop.
 * User: PC05
 * Date: 17/03/2023
 * Time: 01:46 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;

namespace NetworkStream__Servidor_
{
	class Program
	{
		const int puerto= 9999;
		public static void Main(string[] args)
		{
			
			//ProporcionarIP();
			Menu();
			Console.ReadKey(true);
			
		}
		public static void ProporcionarIP()
		{
			Console.WriteLine(" introduce la direccion ip");
			string direccionIp = Console.ReadLine();
			Console.WriteLine("Elija una de las opciones");
			string mensaje = Console.ReadLine();
			IPEndPoint oIPEndPoint =new IPEndPoint(IPAddress.Parse(direccionIp),puerto);
			Socket oSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
			oSocket.Connect(oIPEndPoint);
			oSocket.Send(Encoding.ASCII.GetBytes(mensaje));
			oSocket.Close();
		}
		
		public static void Menu(){
			
			int opcion;
				do{
				Console.ForegroundColor = ConsoleColor.DarkGreen;
					Console.WriteLine("Elija Una De Las Opciones");
					Console.WriteLine("1: Quitar Iconos Del Escritorio");
					Console.WriteLine("2: Directiva2");
					Console.WriteLine("3: Directiva3");
					Console.WriteLine("4: Directiva4");
					Console.WriteLine("5: Directiva5");
					Console.WriteLine("6: Ejecutar programa");
					Console.WriteLine("7: Terminar programa");
					Console.WriteLine("8: Lista de procesos");
			
			opcion = int.Parse(Console.ReadLine());
			
			switch(opcion)
			{
				case 1:
					Console.WriteLine("Selecciono la opcion 1 ");
					RegistroWindows();
					EliminarExplorador();
					break;
					
				case 2: 
					Console.WriteLine("Selecciono la opcion 2 ");
					break;
					
				case 3:
					Console.WriteLine("Selecciono la opcion 3 ");
					break;
					
				case 4:
					Console.WriteLine("Selecciono la opcion 4 ");
					break;
					
				case 5:
					Console.WriteLine("Selecciono la opcion 5 ");
					break;
					
				case 6:
					Console.WriteLine("Selecciono la opcion 6 ");
					break;
					
				case 7:
					Console.WriteLine(" Selecciono la opcion 7 ");
					break;
					
				case 8:
					Console.WriteLine(" Selecciono la opcion 8 ");
					break;
					
				default:
					Console.WriteLine(" Opcion invalida ");
					break;
			}
			Console.WriteLine();
			}while (opcion != 8);
				
		}
		
		public static void RegistroWindows(){
			string UserRoot = "HKEY_CURRENT_USER";
			string subkey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer";
			string keyName = UserRoot + "\\" + subkey;
			Console.WriteLine("1 : Mostrar Archivos Ocultos");
			Console.WriteLine("2 : Ocultar Archivos Ocultos");
			
			ConsoleKeyInfo reg = Console.ReadKey();
			
			if(reg.Key == ConsoleKey.D1){
				Registry.SetValue(keyName,"NoDesktop", 0, RegistryValueKind.DWord);
			}else{
				Registry.SetValue(keyName,"NoDesktop", 1, RegistryValueKind.DWord);
			}
		}
		
		public static void EliminarExplorador(){
			Process[] proceso = Process.GetProcessesByName("explorer");
			proceso[0].Kill();
		}
  
	}
}
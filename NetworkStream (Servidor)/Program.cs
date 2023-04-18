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
					Console.WriteLine("Elija Una De Las Opciones");
					Console.WriteLine("1: Quitar Iconos Del Escritorio");
					Console.WriteLine("2: Quitar Opcion De Apagado");
					Console.WriteLine("3: Desactivar Panel De Control");
					Console.WriteLine("4: Desactivar Click Derecho De La Barra De Tareas");
					Console.WriteLine("5: Desactivar Click Derecho Del Escritorio");
					Console.WriteLine("6: Ejecutar programa");
					Console.WriteLine("7: Terminar programa");
					Console.WriteLine("8: Lista de procesos");
					Console.WriteLine("9: Salir :) ");
			
			opcion = int.Parse(Console.ReadLine());
			bool exit = false;
			switch(opcion)
			{
				case 1:
					Console.WriteLine("Selecciono la opcion 1 ");
					RegistroWindows();
					EliminarExplorador();
					break;
					
				case 2: 
					Console.WriteLine("Selecciono la opcion 2 ");
					EliminarApagado();
					EliminarExplorador();
					break;
					
				case 3:
					Console.WriteLine("Selecciono la opcion 3 ");
					EliminarPanelDeControl();
					EliminarExplorador();
					break;
					
				case 4:
					Console.WriteLine("Selecciono la opcion 4 ");
					EliminarClicDerechoBarraTareas();
					EliminarExplorador();
					break;
					
				case 5:
					Console.WriteLine("Selecciono la opcion 5 ");
					EliminarClickDerechoEscritorio();
					EliminarExplorador();
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
					
				case 9:
					Console.WriteLine("Saliendo del programa");
					Console.ReadKey(exit);
					break;
				
					
					
				default:
					Console.WriteLine(" Opcion invalida ");
					break;
			}
			Console.WriteLine();
			}while (opcion != 8);
				
		}
		// opcion 1: Quita los iconos del escritorio
		public static void RegistroWindows(){
			string UserRoot = "HKEY_CURRENT_USER";
			string subkey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer";
			string keyName = UserRoot + "\\" + subkey;
			Console.WriteLine("1 : Mostrar Iconos");
			Console.WriteLine("2 : Ocultar Iconos");
			
			ConsoleKeyInfo reg = Console.ReadKey();
			
			if(reg.Key == ConsoleKey.D1){
				Registry.SetValue(keyName,"NoDesktop", 0, RegistryValueKind.DWord);
			}else{
				Registry.SetValue(keyName,"NoDesktop", 1, RegistryValueKind.DWord);
			}
		}
		//Elimina el explorardo de windows
		public static void EliminarExplorador(){
			Process[] proceso = Process.GetProcessesByName("explorer");
			proceso[0].Kill();
		}
		// opcion 2: Desactiva el boton de apagado
		public static void EliminarApagado(){
			string UserRoot = "HKEY_CURRENT_USER";
			string subkey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer";
			string keyName = UserRoot + "\\" + subkey;
			Console.WriteLine("1 : Activar Opciones De Apagado");
			Console.WriteLine("2 : Desactivar Opciones De Apagado");
			
			ConsoleKeyInfo reg = Console.ReadKey();
			
			if(reg.Key == ConsoleKey.D1){
				Registry.SetValue(keyName,"NoClose", 0, RegistryValueKind.DWord);
			}else{
				Registry.SetValue(keyName,"NoClose", 1, RegistryValueKind.DWord);
			}
		}
		//opcion 3: Desactiva el panel de control
		public static void EliminarPanelDeControl(){
			string UserRoot = "HKEY_CURRENT_USER";
			string subkey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer";
			string keyName = UserRoot + "\\" + subkey;
			Console.WriteLine("1 : Activar Panel De Control");
			Console.WriteLine("2 : Desactivar Panel De Control");
			
			ConsoleKeyInfo reg = Console.ReadKey();
			
			if(reg.Key == ConsoleKey.D1){
				Registry.SetValue(keyName,"NoControlPanel", 0, RegistryValueKind.DWord);
			}else{
				Registry.SetValue(keyName,"NoControlPanel", 1, RegistryValueKind.DWord);
			}
		}
		
		//opcion 4: Desactiva el click derecho de la barra de tareas
		public static void EliminarClicDerechoBarraTareas(){
			string UserRoot = "HKEY_CURRENT_USER";
			string subkey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer";
			string keyName = UserRoot + "\\" + subkey;
			Console.WriteLine("1 : Activar Click Derecho De La Barra De Tareas");
			Console.WriteLine("2 : Desactivar Click Derecho De La Barra De Tareas ");
			
			ConsoleKeyInfo reg = Console.ReadKey();
			
			if(reg.Key == ConsoleKey.D1){
				Registry.SetValue(keyName,"NoTrayContextMenu", 0, RegistryValueKind.DWord);
			}else{
				Registry.SetValue(keyName,"NoTrayContextMenu", 1, RegistryValueKind.DWord);
			}
			
		}
		
		//opcion 5:  Desactiva el click derecho del raton 
		public static void EliminarClickDerechoEscritorio(){
			string UserRoot = "HKEY_CURRENT_USER";
			string subkey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer";
			string keyName = UserRoot + "\\" + subkey;
			Console.WriteLine("1 : Activar Click Derecho Del Escritorio");
			Console.WriteLine("2 : Desactivar Click Derecho Del Escritorio");
			
			ConsoleKeyInfo reg = Console.ReadKey();
			
			if(reg.Key == ConsoleKey.D1){
				Registry.SetValue(keyName,"NoViewContextMenu", 0, RegistryValueKind.DWord);
			}else{
				Registry.SetValue(keyName,"NoViewContextMenu", 1, RegistryValueKind.DWord);
			}
		}
	}
}
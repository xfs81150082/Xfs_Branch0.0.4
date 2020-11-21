﻿using System;
using System.Collections.Generic;

namespace Xfs
{
	[XfsObjectSystem]
	public class XfsOpcodeTypeComponentSystem : XfsAwakeSystem<XfsOpcodeTypeComponent>
	{
		public override void Awake(XfsOpcodeTypeComponent self)
		{
			self.Load();
		}
	}
	
	[XfsObjectSystem]
	public class XfsOpcodeTypeComponentLoadSystem : XfsLoadSystem<XfsOpcodeTypeComponent>
	{
		public override void Load(XfsOpcodeTypeComponent self)
		{
			self.Load();
		}
	}

	public class XfsOpcodeTypeComponent : XfsComponent
	{
		private readonly XfsDoubleMap<int, Type> opcodeTypes = new XfsDoubleMap<int, Type>();
		
		private readonly Dictionary<int, object> typeMessages = new Dictionary<int, object>();

		public void Load()
		{
			this.opcodeTypes.Clear();
			this.typeMessages.Clear();
			
			List<Type> types = XfsGame.EventSystem.GetTypes(typeof(XfsMessageAttribute));
			foreach (Type type in types)
			{
				object[] attrs = type.GetCustomAttributes(typeof(XfsMessageAttribute), false);
				if (attrs.Length == 0)
				{
					continue;
				}
				
				XfsMessageAttribute messageAttribute = attrs[0] as XfsMessageAttribute;
				if (messageAttribute == null)
				{
					continue;
				}

				this.opcodeTypes.Add(messageAttribute.Opcode, type);
				this.typeMessages.Add(messageAttribute.Opcode, Activator.CreateInstance(type));
			}
		}

		public int GetOpcode(Type type)
		{
			return this.opcodeTypes.GetKeyByValue(type);
		}

		public Type GetType(int opcode)
		{
			return this.opcodeTypes.GetValueByKey(opcode);
		}
		public object GetInstance(int opcode)
		{
			return this.typeMessages[opcode];
		}

		public int MessagesCount()
		{
			return typeMessages.Count;
		}
		public string Messages()
		{
			return typeMessages.Values.ToString();
		}
		public string Keys()
		{
			return typeMessages.Keys.ToString();
		}



		// 客户端为了0GC需要消息池，服务端消息需要跨协程不需要消息池
		//		public object GetInstance(ushort opcode)
		//		{
		//#if SERVER
		//			Type type = this.GetType(opcode);
		//			return Activator.CreateInstance(type);
		//#else
		//			return this.typeMessages[opcode];
		//#endif
		//		}

		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}

			base.Dispose();
		}
	}
}
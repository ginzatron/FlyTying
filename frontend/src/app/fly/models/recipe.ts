import { Hook } from './hook';
import { Instruction } from './instruction';
import { Pattern } from './pattern';
import { Supply } from './supply';
import { Thread } from './thread';
import { Tool } from './tool';
export default interface Recipe {
  id: string;
  name: string;
  hook: Hook;
  thread: Thread;
  tools: Tool[];
  supplies: Supply[];
  instructions: Instruction[];
  pattern: Pattern;
  createdAt: string;
  modifiedAt: string;
}

type Handler = () => void;

class EventBus {
  private events = new Map<string, Set<Handler>>();

  on(event: string, handler: Handler) {
    if (!this.events.has(event)) {
      this.events.set(event, new Set());
    }
    this.events.get(event)!.add(handler);
  }

  off(event: string, handler: Handler) {
    this.events.get(event)?.delete(handler);
  }

  emit(event: string) {
    this.events.get(event)?.forEach(handler => handler());
  }
}

export const layoutEvents = new EventBus();
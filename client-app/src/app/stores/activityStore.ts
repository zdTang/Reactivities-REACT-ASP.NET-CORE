import { makeAutoObservable } from "mobx";

export default class ActivityStore {
  title = "Hello from MobX";

  // if not arrow function, then use "action.bound"
  constructor() {
    makeAutoObservable(this);
  }

  setTitle = () => {
    this.title = this.title + "!";
  };
}

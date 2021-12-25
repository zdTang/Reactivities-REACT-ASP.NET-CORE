import { action, makeObservable, observable } from "mobx";

export default class ActivityStore {
  title = "Hello from MobX";

  // if not arrow function, then use "action.bound"
  constructor() {
    makeObservable(this, { title: observable, setTitle: action });
  }

  setTitle=()=>{
    this.title = this.title + "!";
  }
}

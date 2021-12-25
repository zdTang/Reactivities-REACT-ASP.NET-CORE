import { Container } from "semantic-ui-react";
import NavBar from "./NavBar";
import ActivityDashboard from "../../features/activities/dashboard/ActivityDashboard";
import { observer } from "mobx-react-lite";
import HomePage from "../../features/home/HomePage";
import { Route } from "react-router-dom";
import ActivityForm from "../../features/activities/form/ActivityForm";

function App() {
  return (
    <>
      <NavBar />
      <Container style={{ marginTop: "7em" }}>
        {/* which one match the URL, will display this component */}
        {/* use "exact" key word to match strictly */}
        <Route exact path="/" component={HomePage} />
        <Route path="/activities" component={ActivityDashboard} />
        <Route path="/createActivity" component={ActivityForm} />
        {/* <ActivityDashboard /> */}
      </Container>
    </>
  );
}

export default observer(App);

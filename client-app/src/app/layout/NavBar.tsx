import React from "react";
import { Container, Menu } from "semantic-ui-react";
import { useStore } from "../stores/store";


export default function NavBar() {
  const {activityStore}=useStore();
  return (
    <Menu inverted fixed="top">
      <Container>
        <Menu.Item header>
          <img
            src="/assets/logo.png"
            alt="logo"
            style={{ marginRight: "10em" }}
          />
          Reactivities
        </Menu.Item>
        <Menu.Item name="Activities" />
        <Menu.Item>
          {/* <Button positive content="Create Activity" /> */}
          {/* the button cause Error at the Browser */}
          <button onClick={()=>activityStore.openForm()}>Create Activity</button>
        </Menu.Item>
      </Container>
    </Menu>
  );
}

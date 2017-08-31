import React, { Component } from 'react';
import { 
  AppRegistry, 
  View, 
  Text,
  Button
} from 'react-native';
import CliqzWebView from './CliqzWebView';

class Tab extends Component {

  render() {
    if (!this.state) {
      return <View style={{flex: 1}}>
        <Button
         onPress={this.navigateTo.bind(this, "https://qwant.com")}
         title="qwant.com"
         accessibilityLabel="Go to page"
        />
      </View> 
    }
    const { url } = this.state;

    return <View style={{flex: 1}}>
      <Text style={{ marginLeft: 150, fontSize: 20 }}>{url}</Text>
      <CliqzWebView
        source={{uri: url}}
        onNavigationStateChange={this.onNavigationStateChange.bind(this)}
        onNewWindowRequested={this.onNewWindowRequested.bind(this)}
      />
    </View>
  }

  navigateTo(url) {
    this.setState({ url });
  }

  onNavigationStateChange(state) {
    console.log('navigation state', state);
    this.setState(state);
  }

  onNewWindowRequested(state) {
    console.log('new window requested', state);
  }
}

AppRegistry.registerComponent('CliqzS', () => Tab);
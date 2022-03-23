import React from 'react';

import {ComponentMeta, ComponentStory} from '@storybook/react';
import AuthPage from "./AuthPage";

export default {
    title: 'Pages/AuthPage',
    component: AuthPage,
    argTypes: {},
    parameters: {
        layout: "fullscreen"
    }
} as ComponentMeta<typeof AuthPage>;

const Template: ComponentStory<typeof AuthPage> = ({...args}) => {
    return <AuthPage {...args} />;
};

export const Default = Template.bind({});
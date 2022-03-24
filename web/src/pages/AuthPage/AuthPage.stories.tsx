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

const Template: ComponentStory<any> = () => {
    return <AuthPage />;
};

export const Default = Template.bind({});
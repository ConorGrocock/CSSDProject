import React from 'react';

import {ComponentMeta, ComponentStory} from '@storybook/react';
import LoginPage from "./LoginPage";

export default {
    title: 'Pages/LoginPage',
    component: LoginPage,
    argTypes: {},
} as ComponentMeta<typeof LoginPage>;

const Template: ComponentStory<typeof LoginPage> = () => {
    return <LoginPage />;
};

export const Default = Template.bind({});